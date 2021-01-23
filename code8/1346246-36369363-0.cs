    public static bool AreEqual(string firstNumber, string secondNumber)
    {
        // Code assumes firstNumber and secondNumber are actually numeric values in string form; you can add code to verify that if that assumption isn't right
        return RemoveLeadingZeros(firstNumber) == RemoveLeadingZeros(secondNumber);
    }
