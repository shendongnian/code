    public static class DataReaderMock
    {
        public static void SetupDataReader(this Mock<IDataReader> mock, ICollection<string> columns, object[,] values)
        {
            if (columns.Count != values.GetLength(1))
            {
                throw new ArgumentException($"The number of named columns must be identical to the number of columns in the 2d values array: {columns.Count} compared to {values.GetLength(1)}");
            }
            mock.Setup(reader => reader.FieldCount).Returns(columns.Count);
    
            var setupSequence = mock.SetupSequence(reader => reader.Read());
            var callbacks = new List<Action<object[]>>
            {
                vals => vals.Populate(columns.Cast<object>().ToList())
            };
            for (var row = 0; row < values.GetLength(0); row++)
            {
                var currentRow = row; // for closure
                callbacks.Add(vals => vals.Populate(values, currentRow));
                setupSequence.Returns(true);
            }
            setupSequence.Returns(false);
            mock.Setup(reader => reader.GetValues(It.IsAny<object[]>())).CallbackSequence(callbacks.ToArray());
        }
    
        private static void Populate<T>(this IList<T> target, IList<T> source)
        {
            for (var i = 0; i < target.Count; i++)
            {
                target[i] = source[i];
            }
        }
    
        private static void Populate<T>(this IList<T> target, T[,] sourceTable, int row)
        {
            for (var i = 0; i < sourceTable.GetLength(1); i++)
            {
                target[i] = sourceTable[row, i];
            }
        }
    
        private static void CallbackSequence<T, TResult, TArg>(this ISetup<T, TResult> setup, params Action<TArg>[] callbacks) where T : class
        {
            var queue = new ConcurrentQueue<Action<TArg>>(callbacks);
            setup.Callback((TArg arg) =>
            {
                Action<TArg> callback;
                if (!queue.TryDequeue(out callback))
                {
                    Assert.Fail("More callbacks were invoked than defined in sequence");
                }
                callback(arg);
            });
        }
    }
