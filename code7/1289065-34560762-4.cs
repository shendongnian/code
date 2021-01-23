    dynamic script = CSScript.Evaluator
                         .LoadCode(@"
                                    using System;
                                    using Namespace.Of.The.Context;
                                    public class Executer {
                                        public string Execute(Context ctx) {
                                            return ctx.Person.Firstname + ctx.Person.Lastname;
                                        }
                                    }");
    int result = script.Execute(new Context(new Person("Rick", "Roll")));
