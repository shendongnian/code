     /// <summary>
     /// Override of <see cref="ValidationAttribute.IsValid(object)"/>
     /// </summary>
     /// <remarks>This override performs the specific regular expression matching of the given <paramref name="value"/></remarks>
     /// <param name="value">The value to test for validity.</param>
     /// <returns><c>true</c> if the given value matches the current regular expression pattern</returns>
     /// <exception cref="InvalidOperationException"> is thrown if the current attribute is ill-formed.</exception>
     /// <exception cref="ArgumentException"> is thrown if the <see cref="Pattern"/> is not a valid regular expression.</exception>
