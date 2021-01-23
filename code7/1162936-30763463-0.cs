    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualBasic;
    using System.CodeDom.Compiler;
    using Model;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Newtonsoft.Json;
    
    namespace _30742268 {
    	class Program {
    		const String queryWrapperCode = @"
                Imports System.Linq
                Imports System.Data.Entity
                Imports Model
    
                Public Class DynamicQuery
                    Implements IDynamicQuery
                    Public Function Run(data As IContext) As IQueryable Implements IDynamicQuery.Run
                        Return {0}
                    End Function
                End Class
    		";
    		static void Main(String[] args) {
    			using (var provider = new VBCodeProvider()) {
    				var parameters = new CompilerParameters();
    
    				parameters.ReferencedAssemblies.Add("System.Core.dll");
    				parameters.ReferencedAssemblies.Add("EntityFramework.dll");
                    parameters.ReferencedAssemblies.Add("30742268.exe");
    				parameters.GenerateInMemory = true;
    
    				Console.WriteLine("Enter LINQ queries, 'demo' for an example, 'exit' to stop:");
    				for (;;) {
    					try {
    						var dynamicQueryString = Console.ReadLine();
    						if (dynamicQueryString == "exit")
    							return;
    						if (dynamicQueryString == "demo")
    							Console.WriteLine(dynamicQueryString = "from person in data.People where person.Name.Length = 4");
    
    						var results = provider.CompileAssemblyFromSource(parameters, String.Format(queryWrapperCode, dynamicQueryString));
    						if (results.Errors.HasErrors) {
    							var sb = new StringBuilder();
    							foreach (CompilerError error in results.Errors) {
    								sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
    							}
    							throw new InvalidOperationException(sb.ToString());
    						}
    
    						var assembly = results.CompiledAssembly;
    						var assemblyType = assembly.GetTypes().Single(x => typeof (IDynamicQuery).IsAssignableFrom(x));
    						var constructorInfo = assemblyType.GetConstructor(new Type[] {});
    						var dynamicQuery = (IDynamicQuery) constructorInfo.Invoke(null);
    
    						using (var context = new Context()) {
    							dynamic result = dynamicQuery.Run(context);
    							foreach (var person in result)
    								Console.WriteLine(person);
    						}
    					}
    					catch (Exception exception) {
    						Console.WriteLine(exception);
    					}
    				}
    			}
    		}
    	}
    }
    
    namespace Model {
    	public interface IDynamicQuery {
    		IQueryable Run(IContext context);
    	}
    
    	public abstract class Entity {
    		public override String ToString() {
    			return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    		}
    	}
    
    	public class Person : Entity {
    		public Int64 Id { get; protected set; }
    		public String Name { get; set; }
    		public virtual Home Home { get; set; }
    	}
    
    	public class Home : Entity {
    		public Int64 Id { get; protected set; }
    		public String Address { get; set; }
    		public virtual ICollection<Person> Inhabitants { get; set; } 
    	}
    
    	public interface IContext {
    		IQueryable<Person> People { get; set; }
    		IQueryable<Home> Homes { get; set; }
    	}
    
    	public class Context : DbContext, IContext {
    		public virtual DbSet<Person> People { get; set; }
    		public virtual DbSet<Home> Homes { get; set; }
    
    		IQueryable<Person> IContext.People {
    			get { return People; }
    			set { People = (DbSet<Person>)value; }
    		}
    
    		IQueryable<Home> IContext.Homes {
    			get { return Homes; }
    			set { Homes = (DbSet<Home>)value; }
    		}
    
    		public Context() {
    			Configuration.ProxyCreationEnabled = false;
    			Database.SetInitializer(new ContextInitializer());
    		}
    	}
    	class ContextInitializer : DropCreateDatabaseAlways<Context> {
    		protected override void Seed(Context context) {
    			var fakeSt = new Home {Address = "123 Fake St."};
    			var alabamaRd = new Home {Address = "1337 Alabama Rd."};
    			var hitchhikersLn = new Home {Address = "42 Hitchhiker's Ln."};
    			foreach (var home in new[] {fakeSt, alabamaRd, hitchhikersLn})
    				context.Homes.Add(home);
    
    			context.People.Add(new Person { Home = fakeSt       , Name = "Nick" });
    			context.People.Add(new Person { Home = fakeSt       , Name = "Paul" });
    			context.People.Add(new Person { Home = fakeSt       , Name = "John" });
    			context.People.Add(new Person { Home = fakeSt       , Name = "Henry" });
    			context.People.Add(new Person { Home = alabamaRd    , Name = "Douglas" });
    			context.People.Add(new Person { Home = alabamaRd    , Name = "Peter" });
    			context.People.Add(new Person { Home = alabamaRd    , Name = "Joshua" });
    			context.People.Add(new Person { Home = hitchhikersLn, Name = "Anne" });
    			context.People.Add(new Person { Home = hitchhikersLn, Name = "Boris" });
    			context.People.Add(new Person { Home = hitchhikersLn, Name = "Nicholes" });
    			context.People.Add(new Person { Home = hitchhikersLn, Name = "Betty" });
    			context.SaveChanges();
    		}
    	}
    }
