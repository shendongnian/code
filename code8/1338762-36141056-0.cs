    var operations = new List<Func<CommonObjectArgumentType, OpResult>>
    {
        Operation1,
        Operation2
    };
    OpResult result = OpResult.Success;
    foreach (var op in operations)
    {
        result = op(commonObjectArgument);
        if (result != OpResult.Success)
        {
            trace.exit();
            return result;
        }
    }
    // all operations were successful
