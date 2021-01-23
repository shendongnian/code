    GenerateCodeVM generateCodeVM = new GenerateCodeVM();
    AnimalRepository animalRepository = new AnimalRepository();
    RegionRepository regionRepository = new RegionRepository();
    List<Animal> animal = animalRepository.GetAll().Project().To<AnimalVM>().ToList();
    
    List<Region> region = regionRepository.GetAll().Project().To<RegionVM>.ToList();
