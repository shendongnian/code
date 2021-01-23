    var pagingInstructionFactory = new Mock<IPagingInstructionFactory>();
    this.pagingInstructionFactory
        .Setup(x => x.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IProvider>()))
        .Returns((int skip, int take, IProvider provider) => 
        {
            var instruction = new Mock<IPagingInstruction>();
            instruction.Setup(i => i.Skip).Returns(skip);
            instruction.Setup(i => i.Take).Returns(take);
            instruction.Setup(i => i.Provider).Returns(provider);
    
            return instruction.Object;
        });
