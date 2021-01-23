    IEnumerable<string> columnsToGroupBy = new[] { Names.First()};
                Names.RemoveAt(0);
                Names.Aggregate(columnsToGroupBy, (current, query) => current.Concat(new[] {query}));
                GroupQuery = r => new NTuple<object>(from column in columnsToGroupBy select r[column]);
    ///////
        using System;
        using System.Collections.Generic;
        using System.Linq;
        
        namespace WBTCB.AggregationService.Models.Helpers
        {
            public class NTuple<T> : IEquatable<NTuple<T>>
            {
                public NTuple(IEnumerable<T> values)
                {
                    Values = values.ToArray();
                }
        
                public readonly T[] Values;
        
                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(this, obj))
                        return true;
                    if (obj == null)
                        return false;
                    return Equals(obj as NTuple<T>);
                }
        
                public bool Equals(NTuple<T> other)
                {
                    if (ReferenceEquals(this, other))
                        return true;
                    if (other == null)
                        return false;
                    var length = Values.Length;
                    if (length != other.Values.Length)
                        return false;
                    for (var i = 0; i < length; ++i)
                        if (!Equals(Values[i], other.Values[i]))
                            return false;
                    return true;
                }
        
                public override int GetHashCode()
                {
                    return Values.Aggregate(17, (current, value) => current*37 + (!ReferenceEquals(value, null) ? value.GetHashCode() : 0));
                }
            }
        }
