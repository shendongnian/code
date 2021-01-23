`
StoredProc sp = null; // Guessing the type here
helperMock.Received().ExecuteScalarProcedureAsync(Arg.Do<DatabaseParams>(p => sp = p));
// NUnit assertions, but replace with whatever you want.
Assert.AreEqual("up_Do_Something", sp.StoredProcName);
Assert.AreEqual("Param1", p.Parameters[0].ParameterName);
Assert.AreEqual("Param1Value", p.Parameters[0].Value.ToString());
Assert.AreEqual("Param2", p.Parameters[1].ParameterName);
Assert.AreEqual("Param2Value", p.Parameters[1].Value.ToString());
`
