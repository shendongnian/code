    UniversalContainer<string> stringContainer = new UniversalContainer<string>();      // wrong
    UniversalContainer<BaseClass> baseContainer = new UniversalContainer<BaseClass>();  // right
    UniversalContainer<CoolClass> coolContainer = new UniversalContainer<CoolClass>();  // right
    UniversalContainer<SadClass> sadContainer = new UniversalContainer<SadClass>();     // right
    
    baseContainer.Container.Add(new BaseClass());   // right
    baseContainer.Container.Add(new SadClass());    // right
    baseContainer.Container.Add(new CoolClass());   // right
    
    coolContainer.Container.Add(new BaseClass());   // wrong
    coolContainer.Container.Add(new SadClass());    // wrong
    coolContainer.Container.Add(new CoolClass());   // right
    
    sadContainer.Container.Add(new BaseClass());    // wrong
    sadContainer.Container.Add(new SadClass());     // right
    sadContainer.Container.Add(new CoolClass());    // wrong
