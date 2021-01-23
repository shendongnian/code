    public void FileWithTwoComponents_StartsTwoNewComponents() {
        string filename = "twocomponents.log";
        Mock<IParserBehaviors> mockBehaviors = new Mock<IParserBehaviors>();
        Parser parser = new Parser(mockBehaviors.Object);
        
        parser.ReadFile(filename);
        
        mockBehaviors.Verify(mock => mock.StartNextComponent(), Times.Exactly(2));
    }
