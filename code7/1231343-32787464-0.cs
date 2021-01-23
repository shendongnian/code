        MyObjectView objectView;
        collectionMock
            .Setup(x => x.Save(It.IsAny<MyObjectView>()))
            .Callback<MyObjectView>((obj) => objectView= obj)
            .Returns(It.IsAny<WriteConcernResult>);
        Assert.That(objectView.Id, Is.EqualTo(evt.Id));
        //assert other properties
