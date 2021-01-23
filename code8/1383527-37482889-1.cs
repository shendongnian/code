      var criterion = new AgeCriterion();
      if (age == null)
            return criterion; // fill free to return null if it better suit your needs
            criterion.Age = age.LessThan24.HasValue && age.LessThan24.Value ?
                            criterion.Age | AgeCriterion.BelowTwentyFour : criterion.Age;
            criterion.Age = age.Between24And35.HasValue && age.Between24And35.Value ?
                            criterion.Age | AgeCriterion.TwentyToThirtyFive : criterion.Age;
        .. etc
        return criterion;
