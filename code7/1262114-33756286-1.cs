    public class Child
        {
            ....
            public bool IsEqualsTo(Parent parent)
            {
                return (this.Year == parent.Year) &&
                       (this.Country == parent.Country) &&
                       (this.Season == parent.Season) &&
                       (this.SeasonType == parent.SeasonType)));
            }
        }
