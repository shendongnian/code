    [TestClass]
    public class TC
    {
        [TestMethod]
        public void T()
        {
            var dm = new DomainModel
            {
                Items = new List<IItemType>
            {
                new ItemTypeOne(),
                new ItemTypeOne(),
                new ItemTypeOne(),
                new ItemTypeTwo()
            }
            };
            Mapper.CreateMap<DomainModel, ViewModel>();
            Mapper.CreateMap<ItemTypeOne, ViewModelItemOne>();
            Mapper.CreateMap<ItemTypeTwo, ViewModelItemTwo>();
            Mapper.CreateMap<DomainModel, ViewModel>()
                .ForMember(dest => dest.ItemTypeOnes, opt => opt.MapFrom(src => src.Items.Where(i => i is ItemTypeOne))) 
                .ForMember(dest => dest.ItemsTypeTwos, opt => opt.MapFrom(src => src.Items.Where(i => i is ItemTypeTwo))); ;
            var vm = Mapper.Map<DomainModel, ViewModel>(dm);
            Assert.AreEqual(3, vm.ItemTypeOnes.Count);
            Assert.AreEqual(1, vm.ItemsTypeTwos.Count);
        }
    }
