    public async Task<IEnumerable<PersonView>> GetAllAsync()
            {
                var persons = await _personRepository.GetAllAsync("DisplayAll");
                var personList = PersonExtension.ModelToViewModelCollection(persons);
                return personList;
            }
