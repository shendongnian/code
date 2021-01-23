    {
        "defaultAssembly": "Autofac.Example.Calculator",
        "components": [
            {
                "type": "Autofac.Example.Calculator.Addition.Add, Autofac.Example.Calculator.Addition",
                "services": [
                    {
                        "type": "Autofac.Example.Calculator.Api.IOperation"
                    }
                ],
                "injectProperties": true
            },
            {
                "type": "Autofac.Example.Calculator.Division.Divide, Autofac.Example.Calculator.Division",
                "services": [
                    {
                        "type": "Autofac.Example.Calculator.Api.IOperation"
                    }
                ],
                "parameters": {
                    "places": 4
                }
            }
        ]
    }
