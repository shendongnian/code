    private Measurement ParseExact(AgentParameter agentParameter)
    {
        ControlledElement ce;
        using (var repositoryBase = Datastore.GetRepository<ControlledElement>())
        {
            var mvId = Convert.ToInt32(agentParameter.ControlledParameterId);
            var sId = Convert.ToInt32(agentParameter.FacilityId);
            var query = new ParseExactQuery(mvId, sId);
            ce = repositoryBase.Query(t => t.FirstOrDefault(query.Query));
        }
    }
    private class ParseExactQuery {
        private int mvId;
        private int sId;
        public ParseExactQuery (int mvId, int sId) {
            this.mvId = mvId;
            this.sId = sId;
        }
        public bool Query(ControlledElement elem) {
            return elem.Sensor.Id == sId && elem.MeasuringValue.Id == mvId;
        }
    }
