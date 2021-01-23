    GenerateCodeVM generateCodeVM = new GenerateCodeVM();
    AnimalRepository animalRepository = new AnimalRepository();
    List<Animal> animal = animalRepository.GetAll().ToList();
    RegionRepository regionRepository = new RegionRepository();
    List<Region> region = regionRepository.GetAll().ToList();
    
