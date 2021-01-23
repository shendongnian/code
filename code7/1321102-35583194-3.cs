    public static bool parseAsm(ParserType type, string asmFileContents) {
        switch type {
            case PIC32MX_GCC:
                return PIC32MX_GCC_Parser.ParseAsm(asmFileContents);
            case M16C_IAR:
                return M16C_IAR_Parser.ParseAsm(asmFileContents);
            default:
                throw new NotImplementedException("I dont know this parser type");
        }
    }
