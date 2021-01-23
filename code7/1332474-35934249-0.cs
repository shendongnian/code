        Material nullMaterial = null;
        ...
        repository.Setup(r => r.MaterialAcceptedRepository
          .Get(It.IsAny<int>(), It.IsAny<string>()))
          .Returns(nullMaterial);  
     
