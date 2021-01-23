    var floats = new float[3, 3] {
       { 1f, 2f, 3f },
       { 4f, 5f, 6f },
       { 7f, 8f, 9f }
    };
    Func<float, bool> floatToBool = f => f > 5f;
    var bools =
       floats
       .ToJaggedArray()
       .Select(array => array.Select(floatToBool).ToArray())
       .ToArray()
       .To2DArray();
