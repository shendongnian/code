        static BonusDto YourLogic(Customer customer)
        {
            return new BonusDto() { Retained = customer.Bonuses.Select(b => b.Retained).Sum() };
        }
        static void Main(string[] args)
        {
            AutoMapper.Mapper.CreateMap<Customer, CustomerDto>()
                .ForMember(dto => dto.Bonus, opt => opt.ResolveUsing(YourLogic));
            var customerDto = AutoMapper.Mapper.Map<CustomerDto>(customer);
        }
