    namespace DataIntelligence.Models
    {
    
        public class ExecutionStep
        {
           public Execution Execution {get;set;}
           public Step Step {get;set;}  
    
        }
        public static ExecutionStep Load(int executionStepId)
        {
            // load your execution and step data here and return it
            // within ExecutionStep class object
            ExecutionStep executionStep = new ExecutionStep();
            executionStep.Execution = db.Executions.Find(id); 
            executionStep.Step = db..... // load step from db
            return executionStep;
        }
    }
