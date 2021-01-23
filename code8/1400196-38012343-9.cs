                catch(InvalidCastException)
            {
                output = default(TR);
                //Conversion is not unsupported
            }
                catch(FormatException)
            {
                output = default(TR);
                //string input value was in incorrect format
            }
                catch(InvalidCastException)
            {
                output = default(TR);
                //Conversion is not unsupported
            }
                catch(OverflowException)
            {
                output = default(TR);
                //narrowing conversion between two numeric types results in loss of data
            }
