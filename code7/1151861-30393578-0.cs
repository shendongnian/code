    var data = new List<NoteBook>()
    {
        new NoteBook { OrderNum = 1, Price = 1000, Type = 50 },
        new NoteBook { OrderNum = 2, Price = 2000, Type = 51 },
        new NoteBook { OrderNum = 3, Price = 3000, Type = 52 }
    };
    mock.Setup(m => m.GetNoteBooks()).Returns(data);
    mock.Setup(m => m.GetNoteBookTypeAndProcess(It.IsAny<int>()))
        .Returns((int orderNumber) => data.Single(x => x.OrderNumber == orderNumber).Type);
