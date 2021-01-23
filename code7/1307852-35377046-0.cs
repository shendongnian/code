    using System;
	using MathWorks.MATLAB.NET.Arrays;
	using TrainedClassifierComp;
	namespace ConsoleApplication2
	{
		class Program
		{
			static void Main(string[] args)
			{
				MLTestClass theModel = null;   /* Stores deployment class instance */
				MWStructArray inputs = null;   /* Sample input data */
				MWArray[] result = null;       /* Stores the result */
				MWNumericArray prediction = null;  /* Ouptut data extracted from result */
				MWNumericArray score = null;  /* Ouptut data extracted from result */
				/* Create the new deployment object */
				theModel = new MLTestClass();
				/* Create an MWStructArray */
				String[] myFieldNames = { "1", "2", "3", "4", "5", "6", "7", "8" };
				inputs = new MWStructArray(1, 8, myFieldNames);
				/* Populate struct with some sample inputs  */
				inputs["1", 1] = 1;
				inputs["2", 2] = 2;
				inputs["3", 3] = 3;
				inputs["4", 4] = 4;
				inputs["5", 5] = 5;
				inputs["6", 6] = 6;
				inputs["7", 7] = 7;
				inputs["8", 8] = 8;
				/* Show some of the sample data */
				Console.WriteLine("Inputs: ");
				Console.WriteLine(inputs.ToString());
				/* Pass it to a MATLAB function */
				result = theModel.fnTrainedClassifier(1, inputs);
				prediction = (MWNumericArray) result[0];
				score = (MWNumericArray)result[1];
				/* Show the results */
				Console.WriteLine("Prediction: ");
				Console.WriteLine(prediction.ToString());
				Console.WriteLine("Score: ");
				Console.WriteLine(prediction.ToString());
			}
		}
	}
