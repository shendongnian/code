    dynamic ArrayProperty = new List<dynamic>();
                    var ArrayElements = (Array)Property.GetValue(AnonymousObject);
                    for (var i = 0; i < ArrayElements.Length; i++) {
                        var Element = ArrayElements.GetValue(i);
                        if (IsPrimitive(Element.GetType())) {
                            ArrayProperty.Add(Element);
                        } else {
                            ArrayProperty.Add(ToExpando(Element));
                        }
                    }
