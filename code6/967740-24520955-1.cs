    $c = @"
        public static class Bar {
            public static void foo(string path, string new_name = null, bool save_now = true)
            {
                System.Console.WriteLine(path);
                System.Console.WriteLine(new_name);
                System.Console.WriteLine(save_now);
            }
        }
    "@
    
    add-type -TypeDefinition $c
    
    [Bar]::Foo("test",[System.Management.Automation.Language.NullString]::Value,$false)
