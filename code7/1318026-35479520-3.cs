    number = String.Concat(
                str.Split(new[] { " - " }, StringSplitOptions.None)[0]
                  .Split('/')
                  .Last()
                  .Where(char.IsDigit));
