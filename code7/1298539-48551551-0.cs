    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ForAllMaps((typeMap, mappingExpression) =>
            {
                mappingExpression.ForAllMembers(memberOptions =>
                {
                    memberOptions.Condition((o1, o2, o3, o4, resolutionContext) =>
                    {
                        var name = memberOptions.DestinationMember.Name;
                        if (resolutionContext.Items.TryGetValue(MemberExclusionKey, out object exclusions))
                        {
                            if (((IEnumerable<string>)exclusions).Contains(name))
                            {
                                return false;
                            }
                        }
                        return true;
                    });
                });
            });
        }
        public static string MemberExclusionKey { get; } = "exclude";
    }
