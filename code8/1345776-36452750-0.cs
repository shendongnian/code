        private static void ExecuteMethod(MethodInfo method, object instance)
        {
            try
            {
                method.Invoke(instance, null);
                threadSafeStringBuilder.Append("Test: " + method.Name + " passed");
            }
            catch (UnitTestAssertException utException)
            {
                threadSafeStringBuilder.Append("Test: " + method.Name + " assertion failed" + utException.Message);
				_allPassed = false;
            }
            catch (Exception ex)
            {
                threadSafeStringBuilder.Append("Test: " + method.Name + " exception: " + ex.Message");
            }
        }
		
