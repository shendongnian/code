    public ObservableCollection<TestChoosingPropertyToBind> Test
        {
            get
            {
                return new ObservableCollection<TestChoosingPropertyToBind>(
                    new List<TestChoosingPropertyToBind>()
                    {
                        new TestChoosingPropertyToBind(){EmailAddress = "Test@test.com", PropertyToBindTo = "EmailAddress"},
                        new TestChoosingPropertyToBind(){Name = "Test", PropertyToBindTo = "Name"}
                    }
                    );
            }
        }
