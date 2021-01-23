    public class A 
    {
         public virtual string Text { get; set; }
    }
    
    public class B : A
    {
         // "new" keyword is identifier reusing. You're
         // defining a new member which uses Text again and
         // hides "Text" to references typed as B
         new public string Text { get; set; }
    }
    
    public class X : A
    {
         public override string Text { get; set; }
    }
    
    
    B someB = new B();
    someB.Text = "hello world";
    
    // Now try to access Text property... what happened?
    // Yes, Text property is null, because you're reusing the 
    // identifier in B instead of overriding it
    A someBUpcastedToA = someB;
    string text = someBUpcastedToA.Text;
    
    X someX = new X();
    someX.Text = "goodbye";
    
    // Now if you access someXUpcastedToA.Text
    // property it will give you the "goodbye" string
    // because you're overriding Text in X instead of
    // reusing the identifier
    A someXUpcastedToA = someX;
