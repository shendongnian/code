    var xDocument = XDocument.Parse(@"<configuration>
                                        <property>
                                          <name>name</name>
                                          <value>dinesh</value>
                                        </property>
                                        <property>
                                          <name>city</name>
                                          <value>Delhi</value>
                                        </property>
                                    </configuration>");
    var firstPropertyElement = xDocument
        .Descendants("property")
        .First();//Find your element
    var xComment = new XComment(firstPropertyElement.ToString());//Create comment
    firstPropertyElement.ReplaceWith(xComment);//Replace the element with comment 
    Console.WriteLine(xDocument);
