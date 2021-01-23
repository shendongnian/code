    using System;
    using System.Collections.Generic;
    namespace StateMachineConsoleApp
    {
        public class Program
        {
            public abstract class AbstractState
            {
                static protected Dictionary<string,AbstractState> valuesToStates = new Dictionary<string,AbstractState>();
                protected static List<AbstractState> allowedTransitions = new List<AbstractState>();
                public string StateValue { get; set; }
                public string StateOutput { get; set; }
                protected void RegisterState(AbstractState state, string stateValue, string stateOutput)
                {
                    stateValue = stateValue.ToLower();
                    AddStateToAllowedList(state);
                    AbstractState.valuesToStates.Add(stateValue, state);
                    StateOutput = stateOutput;
                }
                protected void AddStateToAllowedList(AbstractState stateToAdd)
                {
                    if (AbstractState.allowedTransitions.Contains(stateToAdd))
                    {
                        throw new Exception("cannot add state to the allowed list more than once.");
                    }
                    AbstractState.allowedTransitions.Add(stateToAdd);
                    
                }
                public AbstractState DoTransition(string stateToTransitionTo)
                {
                    String stateValueKey = stateToTransitionTo.ToLower();
                    if (!AbstractState.valuesToStates.ContainsKey(stateValueKey))
                    {
                        throw new Exception(String.Format("{0} does not exist",stateValueKey));
                    }
                    AbstractState stateToCheckFor = AbstractState.valuesToStates[stateValueKey];
                    if (AbstractState.allowedTransitions.Exists(item => item.GetHashCode() == stateToCheckFor.GetHashCode()))
                    {
                        AbstractState.allowedTransitions.Remove(stateToCheckFor);
                        return stateToCheckFor;
                    }
                    else
                    {
                        return null;
                    }
                }
                public int CountAllowedStatesRemaining()
                {
                    return allowedTransitions.Count;
                }
            }
            
            public class StartState : AbstractState
            {
                public StartState() { StateValue = "0"; StateOutput = ""; }
            }
            public class HiState : AbstractState
            {
                public HiState()
                {
                    RegisterState(this, "2", "A good job also!");
                }
            }
            public class HelloState : AbstractState
            {
                public HelloState()
                {
                    RegisterState(this, "1","Good job!");
                }
            }
            public class ByeState : AbstractState
            {
                public ByeState()
                {
                    RegisterState(this, "3","many great jobs were had");
                }
            }
            public class ForbiddenState : AbstractState
            {
                public ForbiddenState()
                {
                    StateValue = "-1"; StateOutput = "";
                }
            }
            public class StateMachine
            {
                private AbstractState _currentState = new StartState();
                private ForbiddenState _forbidden = new ForbiddenState();
                public ForbiddenState Forbidden { get { return _forbidden; } }
                public AbstractState CurrentState { get { return _currentState;  } }
                public AbstractState TryTransition(string stateValue)
                {
                    AbstractState nextState = _currentState.DoTransition(stateValue);
                    if (nextState != null) {
                        _currentState = nextState;
                        return CurrentState;
                    } else {
                        return Forbidden;
                    }
                }
                public StateMachine()
                {
                    var hello = new HelloState();
                    var hi = new HiState();
                    var bye = new ByeState();
                }
                public bool IsFinished()
                {
                    return CurrentState.CountAllowedStatesRemaining() == 0;
                }
                   
            }
            static void Main(string[] args)
            {
                List<Char> validInput = new List<Char>();
                validInput.Add('1');
                validInput.Add('2');
                validInput.Add('3');
                var machine = new StateMachine();
                while (!machine.IsFinished())
                {
                    Console.WriteLine("Input a number from 1 to 3, but don't repeat a number you've input previously");
                    var input = Console.ReadKey();
                    Console.WriteLine();
                    if (validInput.Contains(input.KeyChar)) {
                        var newState = machine.TryTransition(input.KeyChar.ToString());
                        if (newState == machine.Forbidden) {
                            Console.WriteLine("You've input that before, try again!");
                        } else {
                            Console.WriteLine(newState.StateOutput);
                        }
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Press any key to exit program");
                var discard = Console.ReadKey();
            }
        }
    }
