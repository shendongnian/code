                _commonFunctionsMock.Expects.AtLeastOne.Method(x => x.GetFeePrice("",false,null))
                .With("BAG1", true, FamilyFaresType.Optima).WillReturn(0);
            _commonFunctionsMock.Expects.AtLeastOne.Method(x => x.GetFeePrice("", false, null))
                .With("BAG2", true, FamilyFaresType.Optima).WillReturn(87);
            _commonFunctionsMock.Expects.AtLeastOne.Method(x => x.GetFeePrice("", false, null))
                .With("BAG3", true, FamilyFaresType.Optima).WillReturn(139);
            _commonFunctionsMock.Expects.AtLeastOne.Method(x => x.GetFeePrice("", false, null))
                .WithAnyArguments().WillReturn(-1);
