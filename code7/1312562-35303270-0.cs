    FacadeMock.Setup(x => x.GetCost(It.IsAny<IContact>()))
		.Returns(() => {
			var myList = new List<ICost>();
			myList.Add(new Mock<ICost>().Object)
				
			// Create your real object here as much as you want 
            // and use myList.Add to add them to your colllection.
				
			return myList;
		}
	);
