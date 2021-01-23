    public void UploadLDTTickets(LDTTicketUploadDTO[] ticketDTOs)
    {
        Mapper.CreateMap<LDTTicketUploadDTO, LDTTicket>();
              .ForMember(d => d.SerialNumber, m => m.MapFrom(s => s.Ticket.SerialNumber))
                  ...
        //Mapper.CreateMap<LDTTicketDTO, LDTTicket>(); You don't need this
        Mapper.CreateMap<LDTCustomerDTO, LDTCustomer>();
        Mapper.CreateMap<LDTDeviceDTO, LDTDevice>();
        ...
    }
