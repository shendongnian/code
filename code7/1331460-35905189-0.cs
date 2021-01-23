    .Block(System.Boolean $variable) {
        .Try {
            .Block() {
                .If (
                    True
                ) {
                    .Call System.Diagnostics.Debug.WriteLine("Start of the equal operation '==': ")
                } .Else {
                    .Default(System.Void)
                };
                $variable = (System.Object).Block(System.Object $variable) {
                    .If (True == False) { // 12 line
                        $variable = .Default(System.Object)
                    } .Else {
                        .Try {
                            .Block() {
                                .If (
                                    True
                                ) {
                                    .Call System.Diagnostics.Debug.WriteLine("Start of the get property operation: _adapter_Name")
                                } .Else {
                                    .Default(System.Void)
                                };
                                $variable = $NewScopeParameter_0._adapter_Name;
                                .If (
                                    True
                                ) {
                                    .Call System.Diagnostics.Debug.WriteLine("End of the get property operation: _adapter_Name")
                                } .Else {
                                    .Default(System.Void)
                                };
                                .Default(System.Void)
                            }
                        } .Catch (System.Exception $var1) {
                            .Block() {
                                .Call System.Diagnostics.Debug.WriteLine("No fue posible obtener la propiedad _adapter_Name, error en la linea: 0 columna: 162 con t1.@event.Adapter.Name")
                                ;
                                .Throw .New Integra.Space.Language.Exceptions.RuntimeException(
                                    "RuntimeException: Line: 0, Column: 162, Instruction: t1.@event.Adapter.Name, Error: RE5: Error with the get property operation",
                                    $var1)
                            }
                        }
                    };
                    $variable
                } == (System.Object).Block(System.Object $variable) {
                    .If (True == False) {
                        $variable = .Default(System.Object)
                    } .Else {
                        .Try {
                            .Block() {
                                .If (
                                    True
                                ) {
                                    .Call System.Diagnostics.Debug.WriteLine("Start of the get property operation: _adapter_Name")
                                } .Else {
                                    .Default(System.Void)
                                };
                                $variable = $NewScopeParameter_1._adapter_Name;
                                .If (
                                    True
                                ) {
                                    .Call System.Diagnostics.Debug.WriteLine("End of the get property operation: _adapter_Name")
                                } .Else {
                                    .Default(System.Void)
                                };
                                .Default(System.Void)
                            }
                        } .Catch (System.Exception $var2) {
                            .Block() {
                                .Call System.Diagnostics.Debug.WriteLine("No fue posible obtener la propiedad _adapter_Name, error en la linea: 0 columna: 188 con t2.@event.Adapter.Name")
                                ;
                                .Throw .New Integra.Space.Language.Exceptions.RuntimeException(
                                    "RuntimeException: Line: 0, Column: 188, Instruction: t2.@event.Adapter.Name, Error: RE5: Error with the get property operation",
                                    $var2)
                            }
                        }
                    };
                    $variable
                };
                .If (
                    True
                ) {
                    .Call System.Diagnostics.Debug.WriteLine("End of the equal operation")
                } .Else {
                    .Default(System.Void)
                };
                .Default(System.Void)
            }
        } .Catch (System.Exception $var3) {
            .Block() {
                .Call System.Diagnostics.Debug.WriteLine("Error con la expresion de igualdad en la linea: 0 columna: 167 con t1.@event.Adapter.Name == t2.@event.Adapter.Name")
                ;
                .Throw .New Integra.Space.Language.Exceptions.RuntimeException(
                    "RuntimeException: Line: 0, Column: 167, Instruction: t1.@event.Adapter.Name == t2.@event.Adapter.Name, Error: RE43: Error with the equal operation '=='",
                    $var3)
            }
        };
        $variable
    }
