        public class DroneDTORepository : IDroneDTORepository
        {
            private readonly DbContext _dbContext;
            public DroneDTORepository(DbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public DroneDTO Get(int id)
            {
                return _dbContext.DroneDTOs.FirstOrDefault(x => x.Id == id);
            }
            public void Save(DroneDTO entity)
            {
                _dbContext.DroneDTOs.Attach(entity);
            }
            public void Delete(DroneDTO entity)
            {
                _dbContext.DroneDTOs.Remove(entity);
            }
            public IEnumerable<DroneDTO> FindAll()
            {
                return _dbContext.DroneDTOs
                    .Select(d => new DroneDTO
                    {
                        iddrones = d.iddrones,
                        //more stuff
                    })
                    .ToList();
            }
            public IEnumerable<DroneDTO> Find(int id)
            {
                return FindAll().Where(x => x.iddrones == id).ToList();
            }
        }
