        [Test]
        public void Some_Test ()
        {
            //Arrange
            string expected_msg = "";
            Messenger.Default.Register<DialogMessage>(this, (o) => {expected_msg=o.Content ;}); 
            CreateSUT();
            //Act
            ..do something here that involves calling that MessageBox
            //Assert
            
            Assert.That(expected_msg, Is.EqualTo(<Some Msg you are sending from ViewModel>));
        }
