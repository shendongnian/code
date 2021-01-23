                       switch (line.Bike.Price)
                        {
                            case Bike.OneThousand:
                               if (line.Quantity >= 20)
                                    thisAmount += line.Quantity * line.Bike.Price * .9d;
                                else
                                    thisAmount += line.Quantity * line.Bike.Price;
                                break;
                            case Bike.TwoThousand:
                                if (line.Quantity >= 10)
                                    thisAmount += line.Quantity * line.Bike.Price * .8d;
                                else
                                    thisAmount += line.Quantity * line.Bike.Price;
                                break;
                       }
