    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace Demo
    {
        sealed class User
        {
            public string Name; // Real code should make these properties.
            public string Age;
            public string Sex;
            public override string ToString()
            {
                return string.Format("Name: {0}, Age: {1}, Sex: {2}", Name, Age, Sex);
            }
        }
        internal static class Program
        {
            static void Main(string[] args)
            {
                string[] source =
                {
                    "[user]",
                    "name1",
                    "age1",
                    "sex1",
                    "",
                    "[user]",
                    "",
                    "name2",
                    "age2",
                    "sex2",
                    "",
                    "[user]",
                    "name3",
                    "age3",
                    "sex3",
                    "",
                    "",
                    "This should be ignored",
                    "So should this",
                    "[user]",
                    "name4",
                    "age4",
                    "sex4"
                };
                var nonblankLines = source.Where(x => !string.IsNullOrWhiteSpace(x));
                // If reading from a file, use this instead:
                // var nonBlankLines = File.ReadLines(filename).Where(x => !string.IsNullOrWhiteSpace(x));
                var users = readUsers(nonblankLines.GetEnumerator());
                Console.WriteLine(string.Join("\n", users)); // Print them out.
                // If for some reason you need a list of users rather than an Enumerable<User>, do this:
                // var listOfUsers = users.ToList();
            }
            static IEnumerable<User> readUsers(IEnumerator<string> input)
            {
                while (true)
                {
                    while (input.Current != "[user]")
                        if (!input.MoveNext())
                            yield break;
                    input.MoveNext();
                    User user = new User();
                    user.Name = input.Current;
                    input.MoveNext();
                    user.Age = input.Current;
                    input.MoveNext();
                    user.Sex = input.Current;
                    yield return user;
                    if (!input.MoveNext())
                        yield break;
                }
            }
        }
    }
                                            
