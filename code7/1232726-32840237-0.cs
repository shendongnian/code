     protected IEnumerable<IEnumerable<ExamCalendar>>ToBlocks(IEnumerable<ExamCalendar> slots)
        {
            using (var ie = slots.OrderBy(slot => slot.StartDate).GetEnumerator())
            {
                var block = new List<ExamCalendar>();
                while (ie.MoveNext())
                {
                    if (block.Count > 0)
                    {
                        if (ie.Current.StartDate.Date != block[block.Count - 1].StartDate.Date && ie.Current.StartDate.Date != block[block.Count - 1].EndDate.AddDays(1).Date)
                        {
                            yield return block;
                            block = new List<ExamCalendar> { ie.Current };
                            continue;
                        }
                    }
                    block.Add(ie.Current);
                }
                yield return block;
            }
        }
