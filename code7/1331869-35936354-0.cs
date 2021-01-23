    var test = new StackLayout
                    {
                        Children =
                        {
                            webImage,
                            storeDetail, //a new stack layout containing all labels that are being binded 
                            collectionLbl,
                            deliveryLbl,
                            orderNowBtn
                        },
                        Padding = new Thickness(10, 20, 10, 20),
                        BackgroundColor = Color.Black
                    };
                    return new ViewCell()
                    {
                        View = test
                    };
