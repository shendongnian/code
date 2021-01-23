        // Load and prepare training data
        var dataSource = new CSVDataSource(@"C:\dev\SO\learning\encog\SO-Test\trainingData.csv", true, CSVFormat.DecimalPoint);
        var data = new VersatileMLDataSet(dataSource);
        data.DefineSourceColumn("EnemyHitPoints", ColumnType.Continuous);
        data.DefineSourceColumn("EnemyCount", ColumnType.Continuous);
        data.DefineSourceColumn("FriendlySquadHitPoints", ColumnType.Continuous);
        data.DefineSourceColumn("FriendlySquadCount", ColumnType.Continuous);
        data.DefineSourceColumn("LocalHitPoints", ColumnType.Continuous);
        //EnemyHitPoints,EnemyCount,FriendlySquadHitPoints,FriendlySquadCount,LocalHitPoints,Action
        ColumnDefinition outputColumn = data.DefineSourceColumn("Action", ColumnType.Nominal);
        data.DefineSingleOutputOthersInput(outputColumn);
        data.Analyze();
        EncogModel model = new EncogModel(data);
        model.SelectMethod(data, MLMethodFactory.TypeNEAT);
        // Now normalize the data. Encog will automatically determine the
        // correct normalization
        // type based on the model you chose in the last step.
        data.Normalize();
        model.SelectTrainingType(data);
        // Build neural net
        var neuralNet = BuildNeuralNet();
        var datainput = data.Select(x => new double[5] { x.Input[0], x.Input[1], x.Input[2],
        x.Input[3], x.Input[4] }).ToArray();
        var dataideal = data.Select(x => new double[1] { x.Ideal[0] }).ToArray();
            IMLDataSet trainingData = new BasicMLDataSet(datainput, dataideal);
            var train = new Backpropagation(neuralNet, trainingData);
            int epoch = 1;
            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch #" + epoch + @"  Error : " + train.Error);
                epoch++;
            } while (train.Error > errorThreshold);
