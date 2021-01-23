    string result = ConcatHelper.Concat(
                        diploma.CodeProfession,
                        new Brace(
                            diploma.CodeDiplomaType,
                            new LabeledItem(label: DiplomaMessage.SrkRegisterId, labelSeparator: " ",
                                valueDecorator: string.Empty, valueToAdd: diploma.SrkRegisterId) 
                            ),
                        diploma.CodeCountry,
                        new Brace(
                            diploma.DateOfIssue?.Year.ToString(CultureInfo.InvariantCulture)
                            ),
                        DiplomaMessage.Recognition
                        ).ToString();
