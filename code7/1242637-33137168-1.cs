    Add-Type @‘
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Linq;
        using System.Management.Automation;
        using System.Management.Automation.Language;
        [Cmdlet(VerbsDiagnostic.Test,"Completion")]
        public class TestCompletionCmdlet : PSCmdlet {
            private string name;
            [Parameter,ArgumentCompleter(typeof(NameCompleter))]
            public string Name {
                set {
                    name=value;
                }
            }
            protected override void BeginProcessing() {
                WriteObject(string.Format("Hello, {0}", name));
            }
            private class NameCompleter : IArgumentCompleter {
                IEnumerable<CompletionResult> IArgumentCompleter.CompleteArgument(string commandName,
                                                                                  string parameterName,
                                                                                  string wordToComplete,
                                                                                  CommandAst commandAst,
                                                                                  IDictionary fakeBoundParameters) {
                    return GetAllowedNames().
                           Where(new WildcardPattern(wordToComplete+"*",WildcardOptions.IgnoreCase).IsMatch).
                           Select(s => new CompletionResult(s));
                }
                private static string[] GetAllowedNames() {
                    return new string[] { "Alice", "Bob", "Charlie" };
                }
            }
        }
    ’@ -PassThru|Select-Object -First 1 -ExpandProperty Assembly|Import-Module
