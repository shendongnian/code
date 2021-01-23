    var moveResolution = new Dictionary<Tuple<Moves, Moves>, Action>
    {
        { new Tuple<Moves, Moves>(Moves.Dodge, Moves.Heavy), MonsterHeavyAttack },
        { new Tuple<Moves, Moves>(Moves.Dodge, Moves.Steath), MonsterStealthAttack },
        { new Tuple<Moves, Moves>(Moves.Charge, Moves.Dodge), MonsterDodge },
        ...
    };
