    public sealed class EditDepartmentCommand : IRequest<Result<int>>
    {
        public int Id { get; }
        public IDictionary<string, object> Operations { get; }
    
        public EditDepartmentCommand(int id, IDictionary<string, object> operations) // (*) We avoid coupling this command to a JsonPatchDocument<DepartmentForUpdateDto> "contract" passing a dictionary with replace operations.
        {
            Id = id;
            Operations = operations;
        }
    }
    
    public sealed class EditDepartmentHandler : BaseHandler, IRequestHandler<EditDepartmentCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnonymousMapper _mapper;
    
        public EditDepartmentHandler(IUnitOfWork unitOfWork, IAnonymousMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    
        public async Task<Result<int>> Handle(EditDepartmentCommand command, CancellationToken token)
        {
            using (var repository = _unitOfWork.GetRepository<Department>())
            {
                var department = await repository.FindAsync(command.Id, true, token).ConfigureAwait(false);
    
                if (department == null) return Result.Fail($"{nameof(EditDepartmentHandler)} failed on edit {nameof(Department)} '{command.Id}'.", StatusCodes.Status404NotFound);   // We could perform a upserting but such operations will require to have guids as primary keys.
    
                dynamic data = command.Operations.Aggregate(new ExpandoObject() as IDictionary<string, object>, (a, p) => { a.Add(p.Key.Replace("/", ""), p.Value); return a; });    // Use an expando object to build such as and "anonymous" object.
    
                _mapper.Map(data, department);                                                                                                                                       //  (*) Update entity with expando properties and his projections, using auto mapper Map(source, destination) overload.
    
                ValidateModel(department, out var results);
    
                if (results.Count != 0)
                    return Result.Fail($"{nameof(EditDepartmentHandler)} failed on edit {nameof(Department)} '{command.Id}' '{results.First().ErrorMessage}'.", StatusCodes.Status400BadRequest);
    
                var success = await repository.UpdateAsync(department, token: token).ConfigureAwait(false) &&                                                                        // Since the entity has been tracked by the context when was issued FindAsync
                              await _unitOfWork.SaveChangesAsync().ConfigureAwait(false) >= 0;                                                                                       // now any changes projected by auto mapper will be persisted by SaveChangesAsync.
    
                return success ?
                    Result.Ok(StatusCodes.Status204NoContent) :
                    Result.Fail<int>($"{nameof(EditDepartmentHandler)} failed on edit {nameof(Department)} '{command.Id}'.");
            }
        }
    
    }
    
    public abstract class BaseHandler
    {
        public void ValidateModel(object model, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();
    
            Validator.TryValidateObject(model, new ValidationContext(model), results, true);
        }
    }
