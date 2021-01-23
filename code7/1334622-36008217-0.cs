    public class ListIsValid : ValidationAttribute
    {
        public override bool IsValid(List animals)
        {
            var regex = new Regex(@"Dog|Cat");
            foreach (string animal in animals)
            {
                if (!regex.IsMatch(animal))
                {
                    return false;
                }
            }
            return true;
        }
    }
