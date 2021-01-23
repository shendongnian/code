    Component.For<TBase>().UsingFactoryMethod(() =>
                {
                    var mockObject = new Mock<TBase>();
                    var mockType = typeof(TBase);
                    if (container is Core.IoCContainer.IoCCore.CustomContainer)
                    {
                        var resolvingDelege = (container as Core.IoCContainer.IoCCore.CustomContainer).ResolvingTestDelegateList[mockType];
                        if (resolvingDelege != null)
                        {
                            resolvingDelege(mockType, mockObject);
                        }
                    }
                    //The changed codes
                    //==============================================
                    var type = mockObject.Object.GetType();
                    var field = type.GetField("__target");
                    field.SetValue(mockObject.Object, new Object());
                    //==============================================
                    return mockObject.Object;
                })
                .LifestyleTransient());
