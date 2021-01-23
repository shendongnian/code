    public class CreateDeviceTypeDTO
    {
        public CreateDeviceTypeDTO()
        {
            PinDetails = new List<DetailsDTO>();
        }
        public string Name{ get; set; }
        public List<DetailsDTO> PinDetails { get; set; } 
    }
