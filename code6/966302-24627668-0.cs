    <#@ template language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="Namespace.With.DbContextBuilderFactory" #>
    
    <#+
    // Keep code you want to reuse in a separate tt file
    public class TemplateManager
    {
      // properties
      // parse DbContextBuilderFactory
      public static IEnumerable<string> ParseDbContextBuilderFactory()
      {
        DbContextBuilderFactory dbf= new DbContextBuilderFactory();
    	return dbf.Tests;
      }
    }
