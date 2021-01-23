    ValidateAny(3); // Uses the int overload
    ValidateAny((object)3); // Uses the int overload as well - dynamic handles the unboxing
    ValidateAny(3M); // Uses the decimal overload
    ValidateAny(3.ToString()); // Uses the string overload
    ValidateAny(3f); // Uses the object overload, since there's no better match
