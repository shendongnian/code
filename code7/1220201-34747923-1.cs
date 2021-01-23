        public interface IDroneDTORepository : IRepository<DroneDTO, int>
        {
            IEnumerable<DroneDTO> FindAll();
    
            IEnumerable<DroneDTO> Find(int id);
        }
