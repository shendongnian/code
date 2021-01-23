    foreach (var objTemp in objList)
                                {
                                    bool isNotSimilar = true;
                                    foreach (string property in otherProperties)
                                    {
                                        //get sending object property data
                                        object tempFValue = (objTemp as IDictionary<string, Object>)[property];
                                        //get current  object property data
                                        object tempCValue = (dynamicObj as IDictionary<string, Object>)[property];
                                        if (!tempFValue.Equals(tempCValue))
                                        {
                                            isNotSimilar = false;
                                            break;
                                        }
                                    }
                                    if (isNotSimilar)
                                    {
                                        isDuplicate = true;
                                        break;
                                    }
                                }
