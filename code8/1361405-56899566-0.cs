	Eventaggregator.Setup(c => c.GetEvent<YourEvent>()
								 .Subscribe(It.IsAny<Action<string>>(),
											It.IsAny<ThreadOption>(), 
											It.IsAny<bool>(),
											It.IsAny<Predicate<string>>()))
					.Returns(YourHandleFunc);
