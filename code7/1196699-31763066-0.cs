    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TextReader rdr = new StreamReader(new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        @"/* comment */ 
                        WITH CteUpdate 
                        AS
                        (
                            SELECT * FROM Table1 
                            WHERE Col1 = 1
                        )
                        UPDATE CteUpdate SET city = ""NY"" WHERE name = ""tom""")
                    ));
                TSql110Parser parser = new TSql110Parser(true);
    
                IList<ParseError> errors;
    
                StatementList stmtList = parser.ParseStatementList(rdr, out errors);
                // Process errors
                foreach(TSqlStatement stmt in stmtList.Statements)
                {
                    Console.WriteLine("Statement type {0}", stmt.GetType());
                    if (stmt is SelectStatement)
                    {
                        //Process SELECT statment
                    }
                    else if (stmt is UpdateStatement)
                    {
                        //Process UPDATE statment
                        UpdateStatement stmtUpdate = (UpdateStatement)stmt;
                        NamedTableReference tabRef = (NamedTableReference)stmtUpdate.UpdateSpecification.Target;
                        Console.Write(" > UPDATE statement > target object {0}", tabRef.SchemaObject.BaseIdentifier.Value);
                    }
                    else //Process other statments
                    {
                        throw new NotImplementedException();
                    }
                    
                }
            }
        }
    
    }
