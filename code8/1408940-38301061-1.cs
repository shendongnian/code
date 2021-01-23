        List<IActorRef> _matches = new List<IActorRef>();
        public void MatchesSupervisor()
        {
            Receive<SomeCommandToStartANewMatch>(msg =>
            {
                // store the currently active matches somewhere, maybe on a FullTime message they would get removed?
                _matches.Add(Context.ActorOf(MatchActor.Create(msg.SomeMatchId)));
            }
        }
    }
    
