      public void GetAllEligibleUnredeemedPoliciesForEachActiveAgentCodeForTheAgent()
        {
            var AgentPoliciesForEachAgentCode = new List<DtoApp2LeadPolicy>();
            foreach (var agentCode in AllOfTheAgentCodesForTheAgent.Distinct())
            {
                if (AgentPolicies != null) AgentPolicies.Clear();
                SetTheAgentCode(agentCode);
                SetAgentPolicyNumbersByAgentCode();
                SetAllPolicyNumbersByAgentsEligiblePolicies();
                SetAgentPoliciesFromAtlamServices();
                if (AgentPolicies != null )
                {
                    AgentPoliciesForEachAgentCode.AddRange(AgentPolicies);
                }
            }
        }
