    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.FxCop;
    using Microsoft.FxCop.Sdk;
    
    
    namespace MyCustomRule
    {
        public class MyCustomRule : BaseIntrospectionRule
        {
            private TypeNode m_ArgumentException;
            string errorMessage, methodName;
            Boolean problemyn;
            public MyCustomRule() :
                base("MyCustomRule", "MyCustomRule.Connection", typeof(MyCustomRule).Assembly)
            {
            }
    
            public override ProblemCollection Check(Member member)
            {
                Method method = member as Method;
    
                MetadataCollection<Instruction> enumerator = method.Instructions;
                methodName = method.Name.ToString();
    
                StatementCollection stmt = method.Body.Statements;
                try
                {
                    problemyn = false;
                    VisitStatements(stmt);
    
                    if (problemyn)
                    {
                        Resolution resolu = GetResolution(new string[] { method.ToString() + errorMessage });
                        Problems.Add(new Problem(resolu));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                return Problems;
            }
    
            public override void VisitExpression(Expression expr)
            {
    
                Construct cnstruct;
                InstanceInitializer instInit;
    
                int i = 0;
                
                cnstruct = expr as Construct;
                  if (cnstruct == null)
                    return;
    
                instInit = (InstanceInitializer)((MemberBinding)cnstruct.Constructor).BoundMember;
    
                foreach (Expression operand in cnstruct.Operands)
                {
                    if (instInit.Parameters[i].Name.Name == "strMethodName")
                    {
                        Literal lit;
                        String litString;
    
                        lit = operand as Literal;
                        if (lit == null)
                            continue;
    
                        litString = lit.Value as String;
                        if (litString == null)
                            continue;
    
                        if (methodName == litString )
                        {
                            break;
                        }
                        else
                        {
                            problemyn = true;
                            errorMessage += methodName + " " + litString;
                        }
                       
    
                    }
                    i++;
                   
                }
    
    
    
            }
        }
    }
